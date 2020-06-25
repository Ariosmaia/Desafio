<h1 align="center">
	Desafio
</h1>

> Status do Projeto: Concluido :heavy_check_mark:

### Tópicos
- [Pré-requisitos](#point_right-pré-requisitos)
- [Como rodar a aplicacão](#arrow_forward-como-rodar-a-aplicacão)
- [Database](#floppy_disk-database)
- [Licença](#memo-licença)

## Pré-requisitos

:warning: [Node](https://nodejs.org/en/download/)

:warning: [SKD .NET Core 3.x](https://dotnet.microsoft.com/download) 


## Como rodar a aplicacão

```
---
git clone https://github.com/Ariosmaia/Desafio.git
```
- Backend:
  - Clique na arquivo da solution
  - Colocar a versão do .Net Core 3.x da sua máquina dentro do arquivo global.json
  ```
    {
    "projects": [ "src", "tests" ],
    "sdk": {
      "version": "3.1.201" // Sua versão aqui
    }
  }
  ```
   - Rodar as migrations (Verifique se o projeto padrão é "EmployeeRegistration.Infra.Data" da camada de Infra)
   ```
   Update-Database
   ```
   
   - Para o rodar o projeto verifique que o projeto padrão esteja em "EmployeeRegistration.Api"
  ---
  
 - FrontEnd:
    - Entre na pasta frontend/employee-registration
    - Instale as pacotes
    
  ```
  npm install
  ```
  
    - Rode a aplicação
  ```
  ng serve
  ```
