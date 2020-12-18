FROM node:10

WORKDIR /app/Frontend

COPY Frontend/*.json /app/Frontend/
RUN npm install -g @angular/cli && npm install

COPY Assets /app/Assets
COPY Frontend/src /app/Frontend/src

CMD ["npm", "start"]