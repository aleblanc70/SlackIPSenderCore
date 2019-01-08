Download image and running dotnet --info
```
docker run --rm -it microsoft/dotnet:2.1-runtime dotnet --info
```
Is Equal because docker is multi-arch so on download it know from what architecture is running from.
```
docker run --rm -it microsoft/dotnet:2.1-runtime-stretch-slim-arm32v7 dotnet --info
```
To Remove am image base on a TAG
pi@raspberrypi:~ $ docker images -a
REPOSITORY          TAG                                IMAGE ID            CREATED             SIZE
microsoft/dotnet    2.1-sdk                            8c0431f30a5d        2 weeks ago         1.58GB
microsoft/dotnet    2.1-runtime                        813c9f82f99c        2 weeks ago         154MB
microsoft/dotnet    2.1-runtime-stretch-slim-arm32v7   813c9f82f99c        2 weeks ago         154MB
```
docker rmi microsoft/dotnet:2.1-runtime-stretch-slim-arm32v7
```
To Remove am image base on a ID
Caution it Remove all images
```
docker rmi 813c9f82f99c
```
Build your images
Base on my Dockerfile I take images 2.1-runtime
```
docker build -f Dockerfile_run -t slackipsendercore_run .
```
Build within the image and you can put more stuff like your unittest etc...
```
docker build -f Dockerfile_sdk -t slackipsendercore_sdk .
```
Run with your images
```
docker run --rm slackipsendercore_run
or
docker run --rm slackipsendercore_sdk
```
