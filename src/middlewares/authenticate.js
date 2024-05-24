const jwt = require("jsonwebtoken");
const authConfig = require("../config/auth.json");

module.exports = (req, res, next) =>{
    console.log("middlewares");
    const authHeader = req.headers.authorization;
    if(!authHeader){
        return res.status(401).json({
            error: true,
            message: "Token no provided"
        });
    }

    const parts = authHeader.split(" ");

    if(parts.length !== 2){
        return res.status(401).json({
            error: true,
            message: "Invalid token type"
        });
    }

    const [scheme, token] = parts;

    if(scheme.indexOf("Bearer") !== 0){
        return res.status(401).json({
            error: true,
            message: "Token malformatted"
        });
    }

    return jwt.verify(token, authConfig.secret, (err, decoded)=>{
        console.log(err);
        console.log(decoded);
        
        if(err){
            return res.status(401).json({
                error: true,
                message: "Token invalid/expired"
            });
        }

        req.userLogged = decoded;
        
        
        console.log(err);
        console.log(decoded);
        return next();
    });

}