FROM node:latest as buid

WORKDIR /usr/local/app
COPY ./ /usr/local/app/
RUN npm install
RUN npm run build

FROM nginx:latest
COPY --from=buid /usr/local/app/dist/fin-app /usr/share/nginx/html
EXPOSE 4200
