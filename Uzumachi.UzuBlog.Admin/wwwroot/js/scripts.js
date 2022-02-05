var Gl = function () {
  if (document.getElementsByClassName("js-simplebar")[0]) {
    var e = new SimpleBar(document.getElementsByClassName("js-simplebar")[0]);
    document.querySelectorAll(".js-sidebar [data-bs-parent]").forEach((function (t) {
      t.addEventListener("shown.bs.collapse", (function () {
        e.recalculate()
      })), t.addEventListener("hidden.bs.collapse", (function () {
        e.recalculate()
      }))
    }))
  }
},
  Ul = function () {
    var e = document.getElementsByClassName("js-sidebar")[0],
      t = document.getElementsByClassName("js-sidebar-toggle")[0];
    e && t && t.addEventListener("click", (function () {
      e.classList.toggle("collapsed"), e.addEventListener("transitionend", (function () {
        window.dispatchEvent(new Event("resize"))
      }))
    }))
  };

function initSidebar() {
  console.log('initSidebar');
  Gl();
  Ul();
}