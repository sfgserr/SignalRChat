# 1. For build React app
FROM node:lts AS development

# Set working directory
WORKDIR /app

# 
COPY package.json /app/package.json
COPY package-lock.json /app/package-lock.json

RUN npm install --force
RUN export NODE_OPTIONS=--openssl-legacy-provider
RUN npm install -g n
RUN n 13.7.0

COPY . /app/

ENV CI=true
ENV PORT=3000

CMD [ "npm", "start" ]

RUN npm run build