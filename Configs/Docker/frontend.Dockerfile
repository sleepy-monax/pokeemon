FROM node:10

WORKDIR /app/Frontend

COPY Assets /app/Assets
COPY Frontend/src /app/Frontend/src
COPY Frontend/*.json /app/Frontend/

RUN npm install -g @angular/cli && npm install

CMD ["npm", "start"]