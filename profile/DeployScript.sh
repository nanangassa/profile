#! /bin/bash

cd ~/projects/profile

dotnet publish -c Release

docker build -t image ./bin/release/netcoreapp2.1/publish

docker build -t image /Users/TheKing/Projects/profile/profile/bin/Release/netcoreapp2.1/publish/

docker tag image registry.heroku.com/franck-nana/web

docker push registry.heroku.com/franck-nana/web

heroku container:release web -a franck-nana
