const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7042';

const PROXY_CONFIG = [
  {
    context: [// пути которые идут на .net должны быть в другом регистре чем пути на ангуляре, иначе не работает
      "/weatherforecast",
      "/glasses",
      "/help",
      "/auth",
      "/user",
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;

