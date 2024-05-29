# Mikrotik Active Connections Exporter for Prometheus

![License](https://img.shields.io/badge/prometheus-exporter-blueviolet)
![License](https://img.shields.io/badge/License-MIT-lightgrey.svg)
![Language](https://img.shields.io/badge/python-v3.8-blue)
[![Docker Image CI](https://github.com/hypeproxy/mikrotik-active-connections-exporter/actions/workflows/docker-image.yml/badge.svg)](https://github.com/hypeproxy/mikrotik-active-connections-exporter/actions/workflows/docker-image.yml)

## Introduction

The Mikrotik Active Connections Exporter monitors and exposes all the active connections on MikroTik routers through Prometheus.

Utilizing the MikroTik API, it fetches active connection information and exposes it as Prometheus metrics. These metrics include details such as protocol, source and destination addresses, and geolocation data retrieved from a GeoIP database, providing a comprehensive view of the network's active connections to aid in network monitoring and management.

## Quick Start


## Exposed Metrics

```
# HELP active_connections Number of active connections
# TYPE active_connections gauge
active_connections 1288
active_connections{protocol="tcp",srcAddress="109.77.102.72:7378",dstAddress="109.77.102.74:6965",replySrcAddress="109.190.102.74:6965",replyDstAddress="109.190.102.72:37319",latitude="48,86",longitude="2,35"} 1
active_connections{protocol="tcp",srcAddress="109.77.102.72:64122",dstAddress="109.77.102.74:6629",replySrcAddress="109.190.102.74:6629",replyDstAddress="109.190.102.72:57901",latitude="48,86",longitude="2,35"} 1
```

## Contributions