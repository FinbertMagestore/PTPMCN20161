Yêu cầu : Cài docker và docker-compose
Thành phần : ubuntu , apache , php , mysql , phpmyadmin , project laravel(origin)
Cách chạy container(môi trường):
1.Mở terminal trên Ubuntu rồi di chuyển đến thư mục dragonmen của project vừa pull (or clone) về .
2.Chạy lênh : 'docker-compose up -d' để run container.
sau đó dùng lênh : 'docker ps -l' để xem container đã chạy chưa và tên của nó (ở đây là dragonmen_laravel_1)

Cách chạy project laravel với container trên:
1.Trên terminal gõ lệnh: 'docker exec -t -i dragonmen_laravel_1 bash' , lúc này các lệnh thực thi trên terminal sẽ dùng môi trường của container(ubuntu).Thư mục thực thi mặc định ở đây là /var/www/html tương ứng với project laravel (có thể thấy ở trên terminal luôn) , điều này giúp thao tác với composer , php artisan và project laravel.
2.Gõ lệnh : 'service apache2 start' để start apache , 'service mysql start' để start mysql.
3.Đến đây bạn đã config xong.