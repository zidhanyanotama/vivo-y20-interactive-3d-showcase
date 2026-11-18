using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColor : MonoBehaviour
{
    public Material[] materials;  // Memungkinkan input warna material dalam ukuran array yang ditentukan
    public Renderer Rend;  // Apa yang kita render? Yang Kita Render adalah Object 3D
    private int index = 1;  // Inisialisasi pada 1, jika tidak, harus menekan tombol 2 kali untuk mengubah warna awal

    public void changeColor(){
    if (materials.Length == 0)  // Jika tidak ada material, tidak ada yang terjadi
            
    return;
    index += 1;  // Ketika tombol ditekan, akan menambahkan nilai ke lokasi indeks berikutnya

  	if (index == materials.Length + 1)  // Ketika mencapai akhir daftar material, mulai dari awal
        index = 1;

        print(index);  // Digunakan untuk debugging 

        Rend.sharedMaterial = materials [index - 1];
        Rend.sharedMaterial = materials [index - 1];    // Ini menetapkan nilai warna material di dalam indeks
    }

}