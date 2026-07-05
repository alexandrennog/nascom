// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Intercepta o submit de qualquer <form data-confirm="mensagem"> e exibe o modal de confirmação
// compartilhado (#confirmModal) antes de deixar o form seguir, reproduzindo o
// MessageBox.Show("Confirma ...?") usado nos formulários WinForms originais.
(function () {
    var modalEl = document.getElementById('confirmModal');
    if (!modalEl) return;

    var modal = new bootstrap.Modal(modalEl);
    var messageEl = document.getElementById('confirmModalMessage');
    var okButton = document.getElementById('confirmModalOk');
    var formPendente = null;

    document.addEventListener('submit', function (event) {
        var form = event.target;
        if (!(form instanceof HTMLFormElement)) return;
        if (form.dataset.confirmed === 'true') return;
        var mensagem = form.getAttribute('data-confirm');
        if (!mensagem) return;

        event.preventDefault();
        formPendente = form;
        messageEl.textContent = mensagem;
        modal.show();
    });

    okButton.addEventListener('click', function () {
        modal.hide();
        if (!formPendente) return;
        formPendente.dataset.confirmed = 'true';
        formPendente.requestSubmit();
        formPendente = null;
    });
})();
