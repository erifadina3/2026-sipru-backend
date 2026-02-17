# SIPRU Backend

Backend API untuk **Sistem Peminjaman Ruangan Kampus (SIPRU)**.  
Project ini menyediakan REST API untuk pengelolaan data peminjaman ruangan kampus.

## Description

SIPRU Backend berfungsi sebagai server-side application yang mengelola data peminjaman ruangan kampus.  
API ini digunakan untuk mendukung aplikasi frontend agar proses peminjaman ruangan dapat dilakukan secara terstruktur, terdokumentasi, dan mudah dikembangkan.

## Features

- CRUD data peminjaman ruangan
- Validasi input data peminjaman
- Update status peminjaman (Menunggu, Disetujui, Ditolak)
- RESTful API
- Dokumentasi API menggunakan Swagger
- Database migration menggunakan Entity Framework Core

## Tech Stack
  
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- PostgreSQL
- Npgsql (PostgreSQL Provider)
- Swagger (API Documentation)

## Installation

### 1. Clone Repository

```bash
git clone https://github.com/erifadina3/2026-sipru-backend.git
cd 2026-sipru-backend/Sipru.Backend
```

### 2. Restore Dependency 

```bash 
dotnet restore
```

## Environment Variables

Konfigurasi database dilakukan pada file `appsettings.json`.
Pastikan database PostgreSQL sudah berjalan sebelum menjalankan aplikasi.

## Usage

### 1. Migrasi Database
```bash
dotnet ef database update
```

### 2. Menjalankan Server

```bash
dotnet run
```
Setelah server berjalan, API dapat diakses melalui:
- API Endpoint
```bash
http://localhost:5153/api/peminjaman
```
- Swagger API Documentation (Development Environment)
```bash
http://localhost:5153/swagger
```

## Author

Dikembangkan oleh Nur Legia Erifadina.
Untuk kebutuhan pembelajaran dan pengembangan sistem peminjaman ruangan kampus

---
Backend ini dikembangkan sebagai bagian dari tugas PRA-PBL.