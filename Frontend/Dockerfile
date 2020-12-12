FROM node:10

WORKDIR /usr/src/app/web

COPY ../Frontend /usr/src/app/web

RUN npm install -g @angular/cli && npm install

EXPOSE 4201

CMD ["npm", "start"]