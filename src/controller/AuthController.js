const express = require("express");
const bcrypt = require("bcryptjs");
const jwt = require("jsonwebtoken");
const UserModel = require("../models/user");
const authConfig = require("../config/auth.json");

const router = express.Router();

router.post("/register", async(req,res)=>{
    const {email} = req.body;
    
    if(await UserModel.findOne({email})){
        return res.status(400).json({
            error:true,
            message:"Email já cadastrado"
        });
    }
    const {cpf} = req.body;
    if(await UserModel.findOne({cpf})){
        return res.status(400).json({
            error:true,
            message:"CPF já cadastrado"
        });
    }

    const user = await UserModel.create(req.body);
    user.senha = undefined;

    console.log(req.body);
    const token = jwt.sign({
        id: user.id,
        name: user.name
    },authConfig.secret,{
        expiresIn: 604800 
    });

    return res.json({user,token});
});

router.post("/authenticate", async(req,res)=>{
    const {email,senha} = req.body;

    const user = await UserModel.findOne({email}).select('+senha');
    if(!user){
        return res.status(400).json({
            error: true,
            message:'Email não encontrado'
        });
    }
    if(!await bcrypt.compare(senha, user.senha)){
        return res.status(400).json({
            error:true,
            message:'Senha inválida'
        });
    }

    user.senha = undefined;
    console.log(user);

    const token = jwt.sign({
        id: user.id,
        name: user.name
    },authConfig.secret,{
        expiresIn: 604800 
    });

    return res.json({user,token});
});

module.exports = router;