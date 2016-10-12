# Docker tutorial

This repository comes with the blog article [From Vagrant to Docker: How to use Docker for local web development](http://tech.osteel.me/posts/2015/12/18/from-vagrant-to-docker-how-to-use-docker-for-local-web-development.html "From Vagrant to Docker: How to use Docker for local web development"). Please refer to it for a full explanation.

It contains a basic LEMP stack running with Docker, intented to be used for local web development.

Refer from project at: https://github.com/osteel/docker-tutorial

## Get started

[Install Docker](https://docs.docker.com/engine/installation/ "Install Docker Engine") on your machine.

From the project root: "Project/"

    $ docker-compose up -d


## Description about Project

  About Project:

   - All config view at "Project/docker-compose.yml".
   - Nginx installed at url: "localhost" and run file "index.php".
   - Access PhpAdmin at url: "localhost:8080" with user and password is "project". It's config at "Project/docker-compose.yml"

 Containers are 6 of them:

  - a container for Nginx
  - a container for PHP-FPM
  - a container for MySQL
  - a container for phpMyAdmin
  - a container to make MySQL data persistent
  - a container for the application code

 All of them are using official images.
