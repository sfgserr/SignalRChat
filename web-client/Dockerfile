# 1. For build React app
FROM node:lts AS development

# Set working directory
WORKDIR /app

# 
COPY package.json /app/package.json
COPY package-lock.json /app/package-lock.json

# Same as npm install
RUN npm install

COPY . /app/

ENV CI=true
ENV PORT=3000

CMD [ "npm", "start" ]

RUN npm run build