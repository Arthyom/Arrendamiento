#!/bin/bash
#cd /home/frodo/Documents/Repos/ArrendamientosFront/
cd /var/www/html/ArrendamientosFrontoGit/
git pull origin master
ng build
cd /var/www/html/ArrendamientosFrontoGit/dist/arrendamientos-front/browser/
cp -R  * /var/www/html/Arrendamiento/

