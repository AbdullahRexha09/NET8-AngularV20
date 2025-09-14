# Project Specification: TUG's Journey Management System

- **Project Name**: TrackBus
- **Company Name**: Trasporti Urbani Globali (TUG)

## Delivery Mode
All the code is commited to this branch abdullahR

## Backend
Backend contains all the crud operation and two Controllers Journey and Stop. The relation of these two entities later is many-to-many

Code is separated in some folders as:
- Controllers
- Database
- DTOs (as records in our case)
- Entities
- Extensions
- Services

## Database
Database i used in memory but also added all SqlServer including connection string from environment and let ready to only add migration and update-database.
The approach used is code first
There is a seeding process happening at the beginning of the app


## Docker & Docker compose
I left as they were as it seems to be working fine. The issue is that i can't activate Hyper-V in my PC as i am working on some virtualization project.


## Angular
Latest approach on angular used including Signals, Standalone Components, Template driven forms, Observable hot/cold.
No third party package was added as it seemed uneccessary

