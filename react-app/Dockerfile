FROM node:16.13 as build

WORKDIR /app

COPY . .

ARG REACT_APP_API_ROOT


RUN npm install

RUN npm run build

FROM nginx:latest
COPY --from=build /app/build /usr/share/nginx/html
CMD ["nginx", "-g", "daemon off;"]
