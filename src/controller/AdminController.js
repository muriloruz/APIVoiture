const express = require("express");
const router = express.Router();
const UserModel = require("../models/user");
router.get("/users",async (req, res) => {
    const user = req.headers;
    
    const espe=JSON.stringify(user); 
    const mau = espe.substring(18,196);
    const userfinal = await UserModel.findOne({token:mau});

    return res.json({userfinal});
});

module.exports = router;