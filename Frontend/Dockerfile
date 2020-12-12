FROM node:10

WORKDIR /usr/src/frontend

COPY src /usr/src/frontend/src
COPY *.json /usr/src/frontend/

RUN npm install -g @angular/cli && npm install

EXPOSE 4201

CMD ["npm", "start"]