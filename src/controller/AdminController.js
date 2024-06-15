const express = require("express");
const router = express.Router();
const UserModel = require("../models/user");
const { getId } = require("./TokensController");

router.get("/users", async (req, res) => {
    const k = req.headers.authorization;
    const id = getId(k);
    if(id == undefined){
        return res.json("User not found");
    }
    return res.json(await findId(id.id));
});

async function findId(id){
    return await UserModel.findOne({"_id":id}).then((e)=>{
        return e;
    });                           
                                                             
}

module.exports = router;