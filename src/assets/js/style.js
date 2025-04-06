// Chuyển đổi icon ở sidebar
 document.addEventListener("DOMContentLoaded", function () {
    const navLinks = document.querySelectorAll(".nav-link");

    navLinks.forEach(link => {
        link.addEventListener("click", function () {
            navLinks.forEach(nav => {
                nav.classList.remove("active");
                const icon = nav.querySelector(".icon");
                if (icon) {
                    icon.classList.remove("fa-solid");
                    icon.classList.add("fa-regular"); 
                }
            });

            this.classList.add("active");
            const selectedIcon = this.querySelector(".icon");
            if (selectedIcon) {
                selectedIcon.classList.remove("fa-regular");
                selectedIcon.classList.add("fa-solid");
            }
        });
    });
});
