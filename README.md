# Parking System

Sistem parkir berbasis .NET 5 menggunakan console sebagai antarmuka. Program ini mengelola parkir kendaraan dengan sistem lot, di mana setiap lot dapat diisi oleh satu mobil atau satu motor. Setiap orang hanya boleh memiliki satu lot.

## Fitur
- **Pembuatan tempat parkir** dengan jumlah lot tertentu.
- **Check-in kendaraan** dengan mencatat nomor polisi, warna, dan jenis kendaraan.
- **Check-out kendaraan** dari slot parkir.
- **Melihat status parkir** termasuk kendaraan yang terparkir dan slot yang tersedia.
- **Laporan** jumlah kendaraan berdasarkan nomor ganjil/genap, jenis kendaraan, dan warna kendaraan.

## Cara Menggunakan

### 1. Menjalankan Program
Program ini berjalan di terminal atau command prompt. Pastikan Anda memiliki .NET 5 atau versi lebih baru yang telah terinstal.

Jalankan program menggunakan perintah berikut:
```sh
 dotnet run
```

### 2. Perintah yang Tersedia

| Perintah | Deskripsi |
|----------|------------|
| `create_parking_lot <jumlah_slot>` | Membuat tempat parkir dengan jumlah slot yang ditentukan. |
| `park <Nomor_Kendaraan> <Warna> <Jenis>` | Memarkir kendaraan jika masih tersedia slot. |
| `leave <Nomor_Slot>` | Mengosongkan slot parkir. |
| `status` | Menampilkan status slot parkir beserta kendaraan yang terisi. |
| `type_of_vehicles <Mobil/Motor>` | Menampilkan jumlah kendaraan berdasarkan jenisnya. |
| `registration_numbers_for_vehicles_with_odd_plate` | Menampilkan nomor kendaraan dengan plat ganjil. |
| `registration_numbers_for_vehicles_with_even_plate` | Menampilkan nomor kendaraan dengan plat genap. |
| `registration_numbers_for_vehicles_with_colour <Warna>` | Menampilkan nomor kendaraan berdasarkan warna. |
| `slot_numbers_for_vehicles_with_colour <Warna>` | Menampilkan nomor slot berdasarkan warna kendaraan. |
| `slot_number_for_registration_number <Nomor_Kendaraan>` | Menampilkan nomor slot berdasarkan nomor kendaraan. |
| `exit` | Keluar dari program. |

### 3. Contoh Penggunaan
```sh
$ create_parking_lot 6
Created a parking lot with 6 slots

$ park B-1234-XYZ Putih Mobil
Allocated slot number: 1

$ park B-9999-XYZ Putih Motor
Allocated slot number: 2

$ leave 1
Slot number 1 is free

$ status
Slot	No.	Type	Registration No	Colour
2	B-9999-XYZ	Motor	Putih

$ exit
```

## Persyaratan
- .NET 5 atau versi lebih baru
- C#

## Instalasi .NET 5 (Jika Belum Terpasang)
Unduh dan instal .NET SDK dari [situs resmi Microsoft](https://dotnet.microsoft.com/en-us/download/dotnet/5.0).

## Pengembangan
Jika ingin mengembangkan lebih lanjut:
1. Clone repositori:
   ```sh
   git clone <repository_url>
   ```
2. Buka project di Visual Studio atau editor pilihan Anda.
3. Modifikasi kode sesuai kebutuhan.
4. Jalankan ulang dengan `dotnet run`.

## Lisensi
Program ini dibuat untuk keperluan tes dan pengembangan. Bebas digunakan dan dimodifikasi.

---
Dikembangkan oleh [Nama Anda]

