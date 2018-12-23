$(document).ready(function () {
    $(document).ajaxSuccess(function (e, xhr, opt) {
        if (opt.url == "/api/skills/1") {
            $(".mySlider").slick({
                speed: 300,
                slidesToShow: 4,
                slidesToScroll: 1,
                infinite: true,
                pauseOnHover: true,
                autoplay: true,
                autoplaySpeed: 5000,
                pauseOnHover: true,
                responsive: [
                    {
                        breakpoint: 1024,
                        settings: {
                            slidesToShow: 3,
                            slidesToScroll: 3,
                            infinite: true
                        }
                    },
                    {
                        breakpoint: 600,
                        settings: {
                            slidesToShow: 2,
                            slidesToScroll: 2
                        }
                    },
                    {
                        breakpoint: 480,
                        settings: {
                            slidesToShow: 1,
                            slidesToScroll: 1
                        }
                    }
                ]
            });
        };
    });
 
});