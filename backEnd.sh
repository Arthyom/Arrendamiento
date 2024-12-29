#!/bin/bash
cd /var/www/html/ArrendamientoGit
git pull origin master
dotnet build
#cd /home/frodo/Documents/Repos/Arrendamiento/Arrendamientos/bin/Debug/net8.0/
cd /var/www/html/ArrendamientoGit/Arrendamientos/bin/Debug/net8.0/
#cp -R  * /var/www/html/Arrendamientos/
cp -R  * /var/www/html/ArrendamientoBack/