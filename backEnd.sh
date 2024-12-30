#!/bin/bash
 service qa.arrendamientos.netcore8 stop
git pull origin master
cd /home/frodo/Documents/Arrendamiento/
dotnet build
#loca cd /home/frodo/Documents/Repos/Arrendamiento/Arrendamientos/bin/Debug/net8.0/
#cp -R  * /var/www/html/Arrendamientos/
#cp -R  * /var/www/html/ArrendamientoBack/
 service qa.arrendamientos.netcore8 start