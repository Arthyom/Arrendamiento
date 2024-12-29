#!/bin/bash
#cd /home/frodo/Documents/Repos/ArrendamientosFront/
cd /home/frodo/Documents/ArrendamientosFront
git pull origin master
ng build
cd dist/arrendamientos-front/browser/
cp -R  * /var/www/html/Arrendamiento/

