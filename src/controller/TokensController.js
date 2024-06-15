var tokens = []
function criarToken(t,i){
    tokens.push({
        token : t, id : i
    });
}
function getId(t){
    console.log(t);
    console.log(tokens);
    return tokens.find((e)=>e.token==t.split(' ')[1]);
}
module.exports = {criarToken,getId};
