#!/bin/sh
sudo docker stop frdemo
sudo docker container rm frdemo
sudo docker run -dit --restart unless-stopped -p 5050:80 --name frdemo frdemo
