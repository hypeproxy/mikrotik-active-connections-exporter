# Mikrotik Active Connections Exporter

![License](https://img.shields.io/badge/Prometheus-Exporter-blueviolet)
[![Publish Docker Image](https://github.com/hypeproxy/mikrotik-active-connections-exporter/actions/workflows/docker-image.yml/badge.svg)](https://github.com/hypeproxy/mikrotik-active-connections-exporter/actions/workflows/docker-image.yml)
![License](https://img.shields.io/badge/License-MIT-lightgrey.svg)
![Language](https://img.shields.io/badge/.NET-8.0%20LTS-blue)

## Introduction

The Mikrotik Active Connections Exporter monitors and exposes all the active connections on MikroTik routers through Prometheus.

Utilizing the MikroTik API, it fetches active connection information and exposes it as Prometheus metrics. These metrics include details such as protocol, source and destination addresses, and geolocation data retrieved from a GeoIP database, providing a comprehensive view of the network's active connections to aid in network monitoring and management.

## Quick Start

To quickly start the Mikrotik Active Connections Exporter Docker container, follow these steps:

### Pull the Docker image:

```bash
docker pull ghcr.io/hypeproxy/mikrotik-active-connections-exporter:latest
```

### Run the Docker container:

```bash
docker run -d \
  -e MIKROTIK_ROUTER_ADDRESS="YOUR_ROUTER_ADDRESS" \
  -e MIKROTIK_ROUTER_PORT="8728" \
  -e MIKROTIK_ROUTER_USERNAME="mikrotik-exporter" \
  -e MIKROTIK_ROUTER_PASSWORD="P4ssw0rd" \
  -p 9021:9021 \
  ghcr.io/hypeproxy/mikrotik-active-connections-exporter:latest
```

Replace the following placeholders with your actual Mikrotik router details:

- `YOUR_ROUTER_ADDRESS`: The IP address of your Mikrotik router.
- `8728`: The port used to connect to your router (default is 8728).
- `mikrotik-exporter`: The username for your router.
- `P4ssw0rd`: The password for your router.

This command will run the exporter in detached mode and map port 9021 of your host to the container, making it accessible for monitoring and analysis.

## Exposed Metrics

```
# HELP active_connections Number of active connections
# TYPE active_connections gauge
active_connections 1288
active_connections{protocol="tcp",srcAddress="109.77.102.72:7378",dstAddress="109.77.102.74:6965",replySrcAddress="109.190.102.74:6965",replyDstAddress="109.190.102.72:37319",latitude="48,86",longitude="2,35"} 1
active_connections{protocol="tcp",srcAddress="109.77.102.72:64122",dstAddress="109.77.102.74:6629",replySrcAddress="109.190.102.74:6629",replyDstAddress="109.190.102.72:57901",latitude="48,86",longitude="2,35"} 1
```

## Contributions

Contributions are welcome! If you have suggestions for improvements, please submit a pull request or open an issue on the GitHub repository.

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
