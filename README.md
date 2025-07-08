# APIVoiture

Essa aplicação é a parte back-end do meu trabalho de graduação na FATEC. Ela é feita em C# com o dotnet 6.

Para executa-la, você necessita, além do c# com o dotnet 6, configurar o MYSQL e o arquivo appsetings.json. No arquivo "json" você deve mudar o campo "HttpsExternal" (caso queira, mude também a "ConnectionString" para o que deseja).

Após isso de o comando "dotnet ef database update" para subir as entidades para o MYSQL. Se tudo der certo, a API está pronta para uso.
