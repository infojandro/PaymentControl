import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider
import com.example.shared.ClientsHelper

class ClientViewModelFactory(private val clientsHelper: ClientsHelper) : ViewModelProvider.Factory {
    @Suppress("UNCHECKED_CAST")
    override fun <T : ViewModel> create(modelClass: Class<T>): T {
        if (modelClass.isAssignableFrom(ClientViewModel::class.java)) {
            return ClientViewModel(clientsHelper) as T
        }
        throw IllegalArgumentException("Unknown ViewModel class")
    }
}
