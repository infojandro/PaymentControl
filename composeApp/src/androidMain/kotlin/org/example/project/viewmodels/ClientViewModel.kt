import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.example.shared.ClientsHelper
import com.example.shared.Client

class ClientViewModel(private val clientsHelper: ClientsHelper) : ViewModel() {

    private val _clients = MutableLiveData<List<Client>>()
    val clients: LiveData<List<Client>> get() = _clients

    private val _client = MutableLiveData<Client?>()
    val client: LiveData<Client?> get() = _client

    fun loadAllClients() {
        _clients.value = clientsHelper.getAllClients()
    }

    fun loadClientById(id: Long) {
        _client.value = clientsHelper.getClientById(id)
    }

    fun addClient(name: String, nick: String?) {
        clientsHelper.insertClient(name, nick)
        loadAllClients()
    }

    fun updateClient(id: Long, name: String, nick: String?) {
        clientsHelper.updateClient(id, name, nick)
        loadAllClients()
    }

    fun deleteClient(id: Long) {
        clientsHelper.deleteClient(id)
        loadAllClients()
    }
}
