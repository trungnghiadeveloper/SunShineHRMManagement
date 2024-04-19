﻿document.addEventListener('DOMContentLoaded', function () {
    const taskItems = document.querySelectorAll('.task-name');

    taskItems.forEach(function (item) {
        item.addEventListener('mouseenter', function () {
            this.classList.add('hovered'); // Thêm class 'hovered' khi hover
        });

        item.addEventListener('mouseleave', function () {
            this.classList.remove('hovered'); // Loại bỏ class 'hovered' khi mất hover
        });

        item.addEventListener('click', function () {
            // Kiểm tra xem thẻ li đã được click hay chưa
            if (this.classList.contains('clicked')) {
                this.classList.remove('clicked'); // Nếu đã click, loại bỏ class 'clicked'
            } else {
                // Nếu chưa click, loại bỏ class 'clicked' ở tất cả các thẻ li khác và thêm class 'clicked' vào thẻ li hiện tại
                taskItems.forEach(function (task) {
                    task.classList.remove('clicked');
                });
                this.classList.add('clicked');
            }
        });
    });

    $(document).ready(function () {
        $('#emps').click(function (event) {
            event.preventDefault();

            $.ajax({
                url: '/Nhanvien/Emp-List',
                success: function (data) {
                    $('#main-content').html(data);
                },
                error: function (error) {
                    console.error("Error loading content:", error);
                }
            });
        });
        $('#departmentFilter, #titleFilter, #positionFilter').change(function () {
            applyFilters();
        });
    });
});

//// Lưu vị trí scroll
//var scrollPosition = $(window).scrollTop();

//// Cập nhật nội dung và vị trí scroll
//$.ajax({
//    url: '/Info/Index',
//    success: function (data) {
//        $('#main-content').html(data);
//        $(window).scrollTop(scrollPosition);
//    },
//    error: function (error) {
//        console.error("Error loading content:", error);
//    }
//});
function redirectToDetail(id) {
    window.location.href = 'Display/' + id;
}
function applyFilters() {
    var departmentFilter = $('#departmentFilter').val();
    var titleFilter = $('#titleFilter').val();
    var positionFilter = $('#positionFilter').val();

    // Gửi yêu cầu Ajax tới controller
    $.ajax({
        url: '/Info/Index',
        type: 'GET',
        data: {
            departmentFilter: departmentFilter,
            titleFilter: titleFilter,
            positionFilter: positionFilter
        },
        success: function (data) {
            // Cập nhật nội dung view với dữ liệu mới từ controller
            $('#resultContainer').html(data);
        }
    });
}