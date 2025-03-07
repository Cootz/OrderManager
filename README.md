# OrderManager
## Quick start
To start app simply clone this repo and run 
```shell
docker-compose up
```
After installation web app will be available at `http://localhost:5000`, public API scheme at `http://localhost:12315/openapi/v1.json`.  
*Note: You can't access PostgreSQL directly. If you want to use PostrgeSQL client expose port 5432 in `compose.yaml`*
## Project info
- **Frontend**: React + Vite + JavaScript  
- **Backend**: .NET 9 + ASP.NET core + EF  
- **Database**: PostgreSQL 17