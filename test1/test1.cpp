#include <bits/stdc++.h>
#include <iostream>
using namespace std;
struct sv{
    char maSV[30];
    char hoDem[50];
    char ten[30];
    char gioiTinh[15];
    int namSinh;
    double diemTK;
};
struct Node {
    sv infor;
    Node* next;
};
typedef Node* TRO;
void create(TRO &L) {
    L = NULL;
}
int isEmpty(TRO L) {
    return L == NULL;
}
void add(TRO &L, sv X) {
    TRO P = new Node;
    P->infor = X;
    P->next = NULL;
    if (isEmpty(L)) L = P;
    else {
        TRO Q = L;
        while (Q->next != NULL) Q = Q->next;
        Q->next = P;
    }
}
void nhap1SV(sv &X) {
    cout << "\tNhap ma sinh vien: ";    
    cin >> X.maSV;
    cout << "\tNhap ho dem: ";
    fflush(stdin);
    //cin.ignore();
    cin.getline(X.hoDem, 25);
    cout << "\tNhap ten: ";
    fflush(stdin);
    cin.getline(X.ten, 100);
    cout << "\tNhap gioi tinh: ";
    fflush(stdin);
    cin.getline(X.gioiTinh, 100);
    cout << "\tNhap nam sinh: ";
    fflush(stdin);
    cin >> X.namSinh;
    cout << "\tNhap diem tong ket: ";
    cin >> X.diemTK;
}
void nhapSV(int &n, TRO &L) {
    cout << "Nhap so luong sinh vien: ";
    cin >> n;
    fflush(stdin);
    cout << "Nhap thong tin cho cac sinh vien\n";
    for (int i = 0; i < n; i++) {
        cout << "Nhap thong tin sinh vien thu " << (i + 1) << ": \n";
        sv X;
        nhap1SV(X);
        add(L, X);
    }
}
void inDS(TRO L) {
    TRO Q;
    cout << setw(3) << right << "\nSTT" << setw(12) << "Ma SV" << setw(16) << "Ho Dem" << setw(8) << "Ten" << setw(14) << "Gioi tinh" << setw(14) << "Nam sinh" << setw(12) << "Diem TK\n";
    if (!isEmpty(L)) {
        Q = L;
        int i = 1;
        while (Q != NULL) {
            cout << setw(3) << right << i << setw(12) << Q->infor.maSV << setw(16) << Q->infor.hoDem << setw(8) << Q->infor.ten << setw(14) << Q->infor.gioiTinh << setw(14) << Q->infor.namSinh << setw(12) << Q->infor.diemTK << "\n";
            cout << "\n";
            i++;
            Q = Q->next;
        }
    }
}

int main()
{
    int n;
    TRO L;
    create(L);
    nhapSV(n, L); 
    inDS(L);
    std::cout << "Hello World!\n";
}
