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

The following metrics are exposed by the service, providing detailed insights into the network activity and geographic distribution of connections on your MikroTik router:

- `mikrotik_total_connections`: A gauge that shows the total number of active connections on the MikroTik router. This metric helps you monitor the overall load and activity on your network.
- `active_connections`: A gauge that indicates the current number of active connections being tracked. This is a more granular count that can help in identifying active sessions and their dynamics over time.

```
# HELP mikrotik_total_connections Total number of active connections on MikroTik router
# TYPE mikrotik_total_connections gauge
mikrotik_total_connections 10668

# HELP active_connections Number of active connections
# TYPE active_connections gauge
active_connections 1288
mikrotik_connection{protocol="tcp",src_address="174.138.11.243",dst_address="72.154.87.221",country="United States",city="Los Angeles",latitude="34.053",longitude="-118.2642"} 22
mikrotik_connection{protocol="tcp",src_address="167.71.66.180",dst_address="72.154.87.221",country="United States",city="New York",latitude="40.7584",longitude="-73.9794"} 31
mikrotik_connection{protocol="tcp",src_address="84.17.41.34",dst_address="72.154.87.221",country="Italy",city="-",latitude="42.8333",longitude="12.8333"} 48
```

## Contributions

Contributions are welcome! If you have suggestions for improvements, please submit a pull request or open an issue on the GitHub repository.

This project is licensed under the MIT License. See the [LICENSE.md](LICENSE.md) file for more details.
