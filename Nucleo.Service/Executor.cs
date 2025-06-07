using System;
using System.ServiceProcess;
using System.Timers;

public partial class MyService : ServiceBase
{
    private Timer _timer;

    public MyService()
    {
        InitializeComponent();
    }

    protected override void OnStart(string[] args)
    {
        _timer = new Timer(60000); // Intervalo de 60 segundos
        _timer.Elapsed += OnTimedEvent;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        // Lógica a ser executada ciclicamente
    }

    protected override void OnStop()
    {
        _timer.Stop();
        _timer.Dispose();
    }
}
