require_relative 'prefab_reader'
# require 'yaml'

class AnimatorEditor < PrefabReader

  def _remove_states(keep_table, remove_table, removed_state_ids, removed_transition_ids)
    # remove transitions' reference in state that point to a
    # deleted transition
    #
    # remove transitions that transit to a deleted state
    modify_inplace_ext do |header, chunk, index|
      if chunk['AnimatorStateTransition:']
        mres = chunk.match(/m_DstState: {fileID: (\d+)}/)
        file_id = mres && mres.captures[0]
        if removed_state_ids[file_id]
          removed_transition_ids[get_file_id(header)] = true
          next '', ''
        end
        next header, chunk
      else
        next header, chunk
      end
    end

    modify_inplace do |chunk|
      if chunk['AnimatorState:']
        sub_chunks = devide_string(chunk, /^  \w/)
        sub_chunks.each_with_index do |sc, index1|
          if sc['m_Transitions:']
            child_states = devide_string(sc, /^  \-/)
            child_states.each_with_index do |cs, index2|
              mres = cs.match(/fileID: (\d+)/)
              file_id = mres && mres.captures[0]
              if removed_transition_ids[file_id]
                child_states[index2] = ''
              end
            end

            org_size = child_states.size
            child_states.reject! do |cs|
              cs == ''
            end
            new_size = child_states.size
            if org_size > 1 && new_size == 1
              child_states = ["  m_Transitions: []\n"]
            end
            sub_chunks[index1] = child_states.join('')
          end
        end

        next sub_chunks.join('')
      else
        next chunk
      end
    end


    # remove states and transitions in state machine
    modify_inplace do |chunk|
      if chunk['AnimatorStateMachine:']

        sub_chunks = devide_string(chunk, /^  \w/)

        sub_chunks.each_with_index do |sc, index1|
          if sc['m_ChildStates:']
            child_states = devide_string(sc, /^  \-/)
            child_states.each_with_index do |cs, index2|
              mres = cs.match(/fileID: (\d+)/)
              file_id = mres && mres.captures[0]
              if removed_state_ids[file_id]
                child_states[index2] = ''
              end
            end
            sub_chunks[index1] = child_states.join('')
          elsif sc['m_AnyStateTransitions:']
            child_states = devide_string(sc, /^  \-/)
            child_states.each_with_index do |cs, index2|
              mres = cs.match(/fileID: (\d+)/)
              file_id = mres && mres.captures[0]
              if removed_transition_ids[file_id]
                child_states[index2] = ''
              end
            end
            sub_chunks[index1] = child_states.join('')
          end
        end

        next sub_chunks.join('')

      elsif chunk['AnimatorController:']
        sub_chunks = devide_string(chunk, /^  \w/)
        sub_chunks.each_with_index do |sc, index1|
          if sc['m_AnimatorParameters:']
            child_states = devide_string(sc, /^  \-/)
            child_states.each_with_index do |cs, index2|
              mres = cs.match(/m_Name: (\w+)/)
              next if mres.nil?
              name = mres && mres.captures[0]
              next if name == 'flip'
              if remove_table && remove_table[name]
                child_states[index2] = ''
              elsif keep_table && !keep_table[name]
                child_states[index2] = ''
              end
            end
            sub_chunks[index1] = child_states.join('')
          end
        end

        next sub_chunks.join('')

      else
        next chunk
      end
    end
  end

  def keep_states_by_names(state_names)
    sn_table = {}
    state_names.each do |sn|
      sn_table[sn] = true
    end

    # remove animator states and transitions
    removed_state_ids = {}
    removed_transition_ids = {}
    modify_inplace_ext do |header, chunk, index|
      if chunk['AnimatorState:']
        o = YAML.load(chunk)
        if !sn_table[o['AnimatorState']['m_Name']]
          removed_state_ids[get_file_id(header)] = true
          next '', ''
        end
        next header, chunk
      elsif chunk['AnimatorStateTransition:']
        o = YAML.load(chunk)
        if !sn_table[o['AnimatorStateTransition']['m_Name']]
          removed_transition_ids[get_file_id(header)] = true
          next '', ''
        end
        next header, chunk
      else
        next header, chunk
      end
    end

    _remove_states(sn_table, nil, removed_state_ids, removed_transition_ids)
  end

  def remove_states_by_names(state_names)

    sn_table = {}
    state_names.each do |sn|
      sn_table[sn] = true
    end

    # remove animator states and transitions
    removed_state_ids = {}
    removed_transition_ids = {}
    modify_inplace_ext do |header, chunk, index|
      if chunk['AnimatorState:']
        o = YAML.load(chunk)
        if sn_table[o['AnimatorState']['m_Name']]
          removed_state_ids[get_file_id(header)] = true
          next '', ''
        end
        next header, chunk
      elsif chunk['AnimatorStateTransition:']
        o = YAML.load(chunk)
        if sn_table[o['AnimatorStateTransition']['m_Name']]
          removed_transition_ids[get_file_id(header)] = true
          next '', ''
        end
        next header, chunk
      else
        next header, chunk
      end
    end

    _remove_states(nil, sn_table, removed_state_ids, removed_transition_ids)
  end

  def remove_unused_states()
    used_file_ids = {}
    asm_chunks = find_chunks('AnimatorStateMachine')
    asm_chunks.each do |chunk_data|
      chunk_data['chunk'].scan(/fileID: (\d+)/) do |sres|
        fid = sres[0]
        used_file_ids[fid] = true
      end
    end

    modify_inplace_ext do |header, chunk, index|
      if chunk['AnimatorState:']
        file_id = get_file_id(header)
        if !used_file_ids[file_id]
          next '', ''
        end
        next header, chunk
      else
        next header, chunk
      end
    end
  end

  # def get_file_id(header)
  #   res = header.match(/\&(\d+)$/)

  #   puts "get_file_id #{res || res[0]}"
  #   return res || res[0]
  # end

  def get_file_id(header)
    res = header.split('&')[1]
    # puts "get_file_id <#{res}>"
    return res
  end

end