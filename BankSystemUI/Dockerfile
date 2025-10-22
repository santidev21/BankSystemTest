
FROM node:16 AS build
WORKDIR /app

COPY package*.json ./

RUN npm install --legacy-peer-deps

COPY . .
RUN npm run build --prod

FROM nginx:alpine
COPY --from=build /app/dist/BankSystemUI /usr/share/nginx/html
COPY default.conf /etc/nginx/conf.d/default.conf
EXPOSE 4200
CMD ["nginx", "-g", "daemon off;"]
