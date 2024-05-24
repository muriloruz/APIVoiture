const mongodb = require("mongoose");
async function connectDB() {
    try{
        await mongodb.connect("mongodb+srv://VoitureMongoDB:lucasemurilo0310@clustervoiture.ru4barw.mongodb.net/api-voiture-mongodb?retryWrites=true&w=majority",{ useNewUrlParser: true, useUnifiedTopology: true });
        console.log('Conexão estável');
    }catch(error){
        console.error('Erro ao conectar ao MongoDB:', error);
    }
}

connectDB();
mongodb.Promise = global.Promise;

module.exports = mongodb;