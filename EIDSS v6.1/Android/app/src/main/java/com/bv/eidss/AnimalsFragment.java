package com.bv.eidss;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ListAdapter;


import com.bv.eidss.model.Animal;

import com.bv.eidss.model.VetCase;
import com.bv.eidss.model.interfaces.IGet;
import com.bv.eidss.model.interfaces.IToChange;

import java.io.Serializable;


public class AnimalsFragment extends CheckableListFragment
            implements IToChange {

    public AnimalsFragment() {
        // Required empty public constructor
    }

    public static AnimalsFragment newInstance() {
        return new AnimalsFragment();
    }

    @Override
    public void onActivityCreated(Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        setListAdapter(new AnimalsListAdapter(this, mCase()));
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        final AnimalsListAdapter adapter = GetAdapter();
        if (adapter != null)
            adapter.updateMenuVisibility(menu);

        super.onPrepareOptionsMenu(menu);
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent intent) {
        if (requestCode == getResources().getInteger(R.integer.ACTIVITY_ID_ANIMAL)) {
            if (resultCode == Activity.RESULT_OK) {
                int position = intent.getIntExtra("position", -1);
                final Animal gotanimal = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ITEM));
                if (position >= 0) {
                    final AnimalsListAdapter list = GetAdapter();
                    if (list != null) {
                        final Animal animal = list.getItem(position);
                        if (animal != null) {
                            animal.setSpeciesType(gotanimal.getSpeciesType());
                            animal.setAnimalAge(gotanimal.getAnimalAge());
                            animal.setAnimalGender(gotanimal.getAnimalGender());
                            animal.setAnimalCondition(gotanimal.getAnimalCondition());
                            animal.FFPresenterCs = gotanimal.FFPresenterCs;
                            updateListItemAtPosition(position);
                        }
                    }
                }
                else {
                    mCase().animals.add(gotanimal);
                    ((AnimalsListAdapter) getListView().getAdapter()).notifyDataSetChanged();
                }
            }
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        switch (item.getItemId()) {
            case R.id.CreateNew:
                final Animal animal = Animal.CreateNew(mCase().getId(), mCase().getNumForNewAnimal(), mCase().getIdForNewAnimal());
                final Intent intent = new Intent(getActivity(), AnimalActivity.class);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEM), animal);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEMS), (Serializable) mCase().getSpecies(getActivity()));
                startActivityForResult(intent, getResources().getInteger(R.integer.ACTIVITY_ID_ANIMAL));
                return true;
            case R.id.Remove:
                final int sel = ((AnimalsListAdapter) getListView().getAdapter()).getCheckItemsCount();
                if(sel == 0) {
                    EidssAndroidHelpers.AlertOkDialog.Show(mActivity.getSupportFragmentManager(), R.string.NothingToDelete);
                    return true;
                }
                //EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getActivity().getSupportFragmentManager(), Species_binding.datStartOfSignsDate_DialogID,
                //        (new Formatter()).format(getActivity().getResources().getString(R.string.ConfirmToDeleteSpecies), sel).toString());
                DeleteAnimals();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    protected AnimalsListAdapter GetAdapter() {
        if(getListView() !=null)    {
            ListAdapter adapter = getListView().getAdapter();
            if (adapter != null && adapter instanceof AnimalsListAdapter) {
                return (AnimalsListAdapter) adapter;
            }
        }
        return null;
    }

    public void updateListItemAtPosition(int position) {
        int visiblePosition = getListView().getFirstVisiblePosition();
        View view = getListView().getChildAt(position - visiblePosition);
        getListView().getAdapter().getView(position, view, getListView());
    }

    public void DeleteAnimals()
    {
        ((AnimalsListAdapter)getListView().getAdapter()).DeleteAnimals();
    }

    private VetCase mCase() {
        return (VetCase)((IGet)mActivity).get();
    }
}
