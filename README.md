# ToDoList (.NET 9 WebAPI + Angular + SQL)

### Hướng dẫn cài đặt và chạy project

#### Clone Repository

```bash
https://github.com/GLNihilis/ToDoList.git
cd todoapi
```

#### Backend

- Mở file `appsettings.json` và chỉnh lại tên SQL ConnectionStrings
- Nếu repo đã có sẵn folder Migrations: 
```bash
dotnet ef database update
```
- Nếu repo chưa có Migrations:
```bash
dotnet ef migrations add init
dotnet ef database update
```
- Cài package:
```bash
dotnet restore
```
- Để chạy: 
```bash
dotnet watch run
```
- Mặc định backend chạy cổng: http://localhost:5192.

### Frontend

- Cài dependencies:
```bash
npm install
```
- Chạy ứng dụng:
```bash
ng serve -o
```
- Ứng dụng mở tại: http://localhost4200.
Khó khăn gặp phải:
<img width="2554" height="442" alt="image" src="https://github.com/user-attachments/assets/af69c18e-d15c-4dc5-88ab-54db8b31fde0" />

### Đang Trong Quá Trình Fix Bug...
