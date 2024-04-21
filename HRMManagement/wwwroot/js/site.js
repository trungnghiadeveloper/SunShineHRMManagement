var $ = jQuery.noConflict();
document.addEventListener('DOMContentLoaded', function () {
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
        $('#departmentFilter, #positionFilter, #titleFilter').change(function () {
            // Update the corresponding filter parameter in the view model
            const departmentFilterValue = $('#departmentFilter').val();
            const positionFilterValue = $('#positionFilter').val();
            const titleFilterValue = $('#titleFilter').val();

            applyFilters(departmentFilterValue, positionFilterValue, titleFilterValue);
        });

        $('.accept-cookie-btn').click(function () {
            // Loại bỏ class 'show' của partial
            $('#offcanvasBackdrop').removeClass('show');
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
    window.location.href = '/Info/Display/' + id;
}
function applyFilters(departmentFilterValue, positionFilterValue, titleFilterValue) {
    $.ajax({
        url: '/Info/Index', // Assuming this is your controller action URL
        type: 'GET', // Use GET for filter requests
        data: {
            departmentFilter: departmentFilterValue,
            positionFilter: positionFilterValue,
            titleFilter: titleFilterValue
        },
        success: function (data) {
            // Update the view content with the filtered data
            $('#resultContainer').html(data);
        },
        error: function (error) {
            console.error("Error filtering:", error);
        }
    });
}