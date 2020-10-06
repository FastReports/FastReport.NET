#!/bin/sh
#sudo docker system prune -f
cp -r ../../Reports .
sudo docker build -t frdemo .
