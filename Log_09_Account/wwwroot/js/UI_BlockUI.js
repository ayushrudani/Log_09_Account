// BlockUI on Ajax Event --------------------------------------------------------------------------------------------
function funBlockUI() {
    $.blockUI({
             overlayColor: '#000000',
        type: 'v2',
        state: 'danger',
        message: '<i class="fa fa-spinner fa-spin me-2"></i> <b class="text-dark">Processing</b> . . .',
        css: {
            padding: '1rem 2rem',
            margin: 0,
            width: '20%',
            top: '40%',
            left: '40%',
            textAlign: 'center',
            color: '#000',
            border: '1px solid #aaa',
            backgroundColor: '#fff',
            cursor: 'wait'
        }, 
        overlayCSS: {
            backgroundColor: '#000',
            opacity: 0.3,
            cursor: 'wait'
        },
    }); 
}

function funUnblockUI() {
    $.unblockUI();
}




