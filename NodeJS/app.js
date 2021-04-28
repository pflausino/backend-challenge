const express = require('express');
const cors = require('cors');
const swaggerJsDoc = require("swagger-jsdoc");
const swaggerUi = require("swagger-ui-express");

const app = express();

app.use(express.json());

const swaggerOptions = {
    swaggerDefinition: {
  openapi: '3.0.0',
        info: {
            version: "1.0.0",
            title: "Real State Budget API",
            description: "Simula o valor para comprar um imovel em determinada cidade",
            contact: {
                name: "Paulo Flausino"
            },
            servers: [
                {
                  url: process.env.LOCAL,
                  description: 'Development server',
                },],
        }
    },
    apis: ['./src/routes.js']
};
const swaggerDocs = swaggerJsDoc(swaggerOptions);

app.disable('etag');
app.use("/api-docs", swaggerUi.serve, swaggerUi.setup(swaggerDocs));


app.use(cors());

app.use("/api", require("./src/routes"));

app.listen(3000);


