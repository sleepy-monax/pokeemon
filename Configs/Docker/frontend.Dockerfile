FROM node:10

WORKDIR /usr/src/Frontend

COPY Assets /usr/src/Assets
COPY Frontend/src /usr/src/Frontend/src
COPY Frontend/*.json /usr/src/Frontend/

RUN npm install -g @angular/cli && npm install

CMD ["npm", "start"]