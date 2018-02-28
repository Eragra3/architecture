#!/bin/sh

# Prepare

echo Starting deployment

builds_folder="$HOME/builds"

mkdir -p $builds_folder
cd $builds_folder

# Pull from GitHub

echo Getting newest version of repository

###########################################################################
# Those are secrets, machine and repository should be kept away from strangers
username="b213104-vagrant"
email="b213104@nwytg.com"
password="uPuQA6hVwJ"
###########################################################################

repo_name="architecture"

# if repository exists already just get the delta
if [ -d $repo_name ]; then
	echo Pulling repository
	cd $repo_name
	git pull
else
	echo Cloning repository
	git clone https://$username:$password@github.com/Eragra3/$repo_name.git
	cd $repo_name
fi

# Build solution

echo Building solution

npm install

# this builds app that requires to be run with 'dotnet app-name.dll' or just 'dotnet run'
dotnet build
# this builds self-contained app
# dotnet publish

# in future this app will be hosted behind reverse proxy like nginx
# Deploy application

# echo Deploying application
