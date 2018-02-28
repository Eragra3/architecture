#!/bin/sh

echo Installing Utilities

echo Installing wget

sudo yum -y install wget

echo Installing zip and unzip

sudo yum -y install zip unzip

echo Installing python-pip

sudo yum -y --enablerepo=extras install epel-release
sudo yum -y install python-pip

# this could be nice, but isn't really working
# echo Installing mdv (Markdown Viewer)

# sudo pip install mdv

echo Installing Nano

sudo yum -y install nano

echo Installing Git

sudo yum -y install git