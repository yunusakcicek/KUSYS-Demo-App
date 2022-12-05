# KUSYS-Demo-App

#Installation requirements: MySql Server, .net Core 6.0 SDK

#Before run application need to change appsettings.json file;

{
  "AppSettings": {
    "MD5Salt": "*************"
  },
   "ConnectionStrings": {
     "DefaultConnection": "server=localhost; port=3306; database=kusys-demo-db; user=root; password=*******; Persist Security Info=False; Connect Timeout=300"
   },
   "Logging": {
     "LogLevel": {
       "Default": "Warning"
     }
   },
   "AllowedHosts": "*"
 }

#Update the DefaultConnection property with your MySql server properties.

#Then you can just start the application it will create database and data with pre-writed data seed.


Test Users;

Admin user credentials for login app as an admin privileges:
Username : admin@ku.edu.tr
Password: 123456

Student user credentials for login app as a student privileges:
Username : student@ku.edu.tr
Password: 123456

After creating a new student in program password automatically creating with rules written down;

#Password => Birth Date of student with this format -> ddMMyyyy and Last Name of student


|| Example password=> Student Birth Date => 12/05/1998, Student Last Name -> Henderson then password is: 12051998Henderson 




