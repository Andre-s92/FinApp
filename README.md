# FinApp
Projeto para lançamento financeiro de antecipação de recebiveis

## Como Executar o projeto
1. Download e instalação do Docker
2. Download do Repositorio do projeto
3. Na raiz do projeto dotnet FinApp\FinApp.Back\FinApp terá um arquivo chamado docker-compose.yml
4. Abra o console nesse diretório
5. Executar o seguinte comando:
```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```
ao executar esse comando a API, a aplicação angular e o banco de dados serão instalados no docker
![image](https://user-images.githubusercontent.com/83170318/230910912-776d9e8d-27b1-4ff0-a1ab-b4cb43674089.png)
