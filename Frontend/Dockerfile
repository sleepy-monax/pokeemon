FROM node:10

WORKDIR /usr/src/frontend

COPY ../Frontend /usr/src/frontend

RUN npm install -g @angular/cli && npm install

EXPOSE 4201

CMD ["npm", "start"]