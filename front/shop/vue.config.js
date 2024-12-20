const { defineConfig } = require('@vue/cli-service');

module.exports = defineConfig({
  transpileDependencies: true,
  devServer: {
    https: false,
    client: {
      webSocketURL: {
        protocol: 'wss',
        hostname: 'zd3rdtwk-8080.euw.devtunnels.ms', //if use remote tunnels ports in vs code
        port: 443,
      },
    },
    allowedHosts: 'all', 
  },
});