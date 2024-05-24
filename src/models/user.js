const mongoose = require("../database/index");
const bcrypt = require("bcryptjs");
const UserSchema = new mongoose.Schema({
    nome:{
        type: String,
        required: true,
        lowercase: true
    },
    email:{
        type: String,
        required: true,
        unique: true,
        lowercase: true
    },
    cpf:{
        type: String,
        required: true,
        unique: true,
        select: false
    },
    telefone:{
        type: String,
        required: true,
    },
    idade:{
        type: Number,
        required: true,
        min: 18
    },
    cep:{
        type: String,
        required: true,
        select: false
    },
    sexo:{
        type: String,
        required: true,
    },
    senha:{
        type: String,
        required: true,
        minlength: 6,
        select: false
    },
    createdAt:{
        type: Date,
        default: Date.now
    }
});
UserSchema.pre("save",async function(next){
    const hash = await bcrypt.hash(this.senha, 10);
    this.senha=hash;
});
const User = mongoose.model("User",UserSchema);
module.exports= User;